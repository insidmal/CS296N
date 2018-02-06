using CrossOutCommunity.Controllers;
using CrossOutCommunity.Models;
using CrossOutCommunity.Repositories;
using System;
using System.Collections.Generic;
using Xunit;

namespace CrossoutCommunity.Tests
{
    public class ContactTests
    {
        IMessageRepository repo;
        ContactController controller;
        List<Message> messages;


        public ContactTests()
        {
            repo = new TestMessageRepository();
            messages = repo.GetAllMessages();
            controller = new ContactController(repo);
        }

        [Fact]
        public void GetMessageTest()
        {

            var mess = controller.ViewContact().ViewData.Model as List<Message>;

           for (int i = 0; i<messages.Count;i++)
            {
                Assert.Equal(messages[i].ContactMessage, mess[i].ContactMessage);
                Assert.Equal(messages[i].ContactUser.EmailAddress, mess[i].ContactUser.EmailAddress);
                Assert.Equal(messages[i].ContactUser.Name, mess[i].ContactUser.Name);

            }

        }

        [Fact]
        public void AddMessageTest()
        {
            messages.Add(new Message { ContactMessage = "New Message", ContactUser = new User { Name="Tj", EmailAddress="em" } });
            Assert.Equal(3, messages.Count);
            Assert.Equal("Tj", messages[2].ContactUser.Name.ToString());

        }


    }
}
