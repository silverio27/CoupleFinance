using Domain.Users;
using Xunit;

namespace UnitTests.Domain
{
    public class EntityUserTests
    {
        User _user;
        public EntityUserTests()
        {
            _user = Builders.UserBuild();
        }
        [Fact]
        public void Create_User_Succefully()
        {

            Assert.True(_user.Active);
            Assert.NotEqual(System.Guid.Empty, _user.Id);
        }

        [Fact]
        public void Create_User_Failed_By_Invalid_Email()
        {
            Assert.Throws<UserException>(() =>
            {

                var user = new User("Lucas Silvério", "");
            });
        }

        [Fact]
        public void Create_User_Failed_By_Invalid_Name()
        {
            Assert.Throws<UserException>(() =>
            {

                var user = new User("", "silverio.des.vargas@gmail.com");
            });
        }

        [Fact]
        public void Change_Password_Sucessfully()
        {
            _user.ChangePassword("Qn7buK!*h38u", "Qn7buK!*h38u");
            bool changed = _user.VerifyPassword("Qn7buK!*h38u");
            Assert.True(changed);
        }

        [Fact]
        public void Change_Password_Failed_By_Confirmation()
        {
            Assert.Throws<UserException>(() =>
            {
                _user.ChangePassword("Qn7buK!*h38u", "NovaSenha");
            });
        }

        [Fact]
        public void Change_Password_Failed_By_Invalid_Characters()
        {
            Assert.Throws<UserException>(() =>
            {
                _user.ChangePassword("NovaSenha", "NovaSenha");
            });
        }

        [Fact]
        public void Change_Password_Failed_By_Empty_Characters()
        {
            Assert.Throws<UserException>(() =>
            {
                _user.ChangePassword("", "");
            });
        }

        [Fact]
        public void Disable_User()
        {
            _user.Disable("Falta de pagamento.");
            Assert.False(_user.Active);
            Assert.NotEmpty(_user.History);
        }
    }
}