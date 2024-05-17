using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System.Net.Http;
using System.Text.Json;
using RailswareTestMailtrap; 

namespace RailswareTestMailtrapTests
{
    [TestClass]
    public class MailClientTests
    {
        [TestMethod]
        public async Task SendAsync_ValidRequest_ReturnsSuccessResponse()
        {
            // Arrange
            var apiToken = "864d8e3dab0b962744f27e30fa8f9f36";
            var mailClient = new MailClient(apiToken);
            var fromName = "John Doe";
            var fromEmail = "mailtrap@demomailtrap.com";
            var toName = "Jane Doe";
            var toEmail = "satlit1c@gmail.com";
            var subject = "Test email";
            var text = "This is a test email";

            // Act
            var response = await mailClient.SendAsync(fromName, fromEmail, toName, toEmail, subject, text);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.IsSuccessful);
        }

        [TestMethod]
        public async Task SendAsync_EmptyToEmail_ThrowsException()
        {
            // Arrange
            var apiToken = "864d8e3dab0b962744f27e30fa8f9f36";
            var mailClient = new MailClient(apiToken);
            var fromName = "John Doe";
            var fromEmail = "mailtrap@demomailtrap.com";
            var toName = "Jane Doe";
            var toEmail = string.Empty;
            var subject = "Test email";
            var text = "This is a test email";

            // Act and Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => mailClient.SendAsync(fromName, fromEmail, toName, toEmail, subject, text));
        }

        [TestMethod]
        public async Task SendAsync_NullSubject_ThrowsException()
        {
            // Arrange
            var apiToken = "864d8e3dab0b962744f27e30fa8f9f36";
            var mailClient = new MailClient(apiToken);
            var fromName = "John Doe";
            var fromEmail = "mailtrap@demomailtrap.com";
            var toName = "Jane Doe";
            var toEmail = "satlit1c@gmail.com";
            var subject = "";
            var text = "This is a test email";

            // Act and Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => mailClient.SendAsync(fromName, fromEmail, toName, toEmail, subject, text));
        }
        [TestMethod]
        public async Task SendAsync_EmptyText_ThrowsException()
        {
            // Arrange
            var apiToken = "864d8e3dab0b962744f27e30fa8f9f36";
            var mailClient = new MailClient(apiToken);
            var fromName = "John Doe";
            var fromEmail = "mailtrap@demomailtrap.com";
            var toName = "Jane Doe";
            var toEmail = "satlit1c@gmail.com";
            var subject = "Test email";
            var text = string.Empty;

            // Act and Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => mailClient.SendAsync(fromName, fromEmail, toName, toEmail, subject, text));
        }
        [TestMethod]
        public async Task SendAsync_InvalidApiToken_ThrowsException()
        {
            // Arrange
            var apiToken = "invalid-api-token";
            var mailClient = new MailClient(apiToken);
            var fromName = "John Doe";
            var fromEmail = "mailtrap@demomailtrap.com";
            var toName = "Jane Doe";
            var toEmail = "satlit1c@gmail.com";
            var subject = "Test email";
            var text = "This is a test email";

            // Act and Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => mailClient.SendAsync(fromName, fromEmail, toName, toEmail, subject, text));
        }
        [TestMethod]
        public async Task SendAsync_NullAttachments_ReturnsSuccessResponse()
        {
            // Arrange
            var apiToken = "864d8e3dab0b962744f27e30fa8f9f36";
            var mailClient = new MailClient(apiToken);
            var fromName = "John Doe";
            var fromEmail = "mailtrap@demomailtrap.com";
            var toName = "Jane Doe";
            var toEmail = "satlit1c@gmail.com";
            var subject = "Test email";
            var text = "This is a test email";
            string[] attachments = null;

            // Act
            var response = await mailClient.SendAsync(fromName, fromEmail, toName, toEmail, subject, text, attachments: attachments);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.IsSuccessful);
        }
    }
}