using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
	public class LoginManager : ILoginService
	{
		IAdminDal _adminDal;
        public LoginManager(IAdminDal adminDal)
        {
			_adminDal= adminDal;

		}

	    public Admin Login(string username, string password)
		{
			return _adminDal.Get(x => x.AdminUserName == username && x.AdminPassword == password);
		}
	}
}
