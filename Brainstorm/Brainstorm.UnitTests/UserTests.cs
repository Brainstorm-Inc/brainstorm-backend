using Brainstorm.Entities.User;
using NUnit.Framework;

namespace Brainstorm.Testing
{
    [TestFixture]
    public class UserTests
    {

        [Test]
        public void UserCreate_GoodAttributes_Pass()
        {
            string fName = "FirstName";
            string lName = "LastName";
            string email = "first-last@mail.com";
            string profilePic = "https://robohash.org/FirstName-LastName.png";

            User user = new User(fName, lName, email);
            
            Assert.AreEqual(fName,user.FirstName);
            Assert.AreEqual(lName,user.LastName);
            Assert.AreEqual(email,user.Email);
            Assert.AreEqual(profilePic,user.ProfilePicture);

        } 
        
    }
}