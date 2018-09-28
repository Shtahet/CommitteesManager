using CommitteesManager.BLL.Abstract;
using CommitteesManager.DAL.Abstract;
using CommitteesManager.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommitteesManager.BLL.Concrete
{
    public class UserProvider:IUserService
    {
        private IDataProvider _dataProvider;
        public UserProvider(IDataProvider incomingProvider)
        {
            _dataProvider = incomingProvider;
        }

        public void AddOrUpdate(User obj)
        {
            _dataProvider.Users.AddOrUpdate(obj);
        }

        public void Delete(string Id)
        {
            _dataProvider.Users.Delete(new User() { UserID = Id });
        }

        public void Delete(User obj)
        {
            _dataProvider.Users.Delete(obj);
        }

        public IEnumerable<User> FindBy(Expression<Func<User, bool>> predicate)
        {
            return _dataProvider.Users.FindBy(predicate).AsEnumerable();
        }

        public User Get(string Id)
        {
            return _dataProvider.Users.Get(Id);
        }

        User ITemplateService<User>.Get(object key)
        {
            if(!(key is string))
            {
                return null;
            }
            return Get((string)key);
        }

        public IEnumerable<User> GetActualAll()
        {
            return _dataProvider.Users.GetAll().Where(u => u.Is_available == true).AsEnumerable();
        }

        public IEnumerable<User> GetAll()
        {
            return _dataProvider.Users.GetAll().AsEnumerable();
        }
    }
}
