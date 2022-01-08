using Domain.Users;

namespace UnitTests
{
    public static class Builders
    {
        private static  User _user;
        public static User UserBuild()
        {
            _user = new User("Lucas Silvério","silverio.des.vargas@gmail.com");
            return _user;
        }
    }
}