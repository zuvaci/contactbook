using ContactBook.Models;
using ContactBook.Interface;
using SQLitePCL;
namespace ContactBook.Service
{
    public class ContactService : Interface.IContactService
    {
        private readonly AppDbContext _context;
        public ContactService(AppDbContext context)
        {
            _context = context;
        }
        public Contact Add(Contact contact)
        {
            var entity = new Entities.Contact();
            entity.FirstName = contact.FirstName;
            entity.LastName = contact.LastName;
            entity.Email = contact.Email;
            entity.FullName = contact.FirstName + " " + contact.LastName;

            _context.Add(entity);
            _context.SaveChanges();
            return contact;
        }


        public bool Delete(Contact contact)
        {
            var entity = _context.Contacts.FirstOrDefault(x => x.Id == contact.Id);
            if(entity != null)
            {
                _context.Contacts.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Contact> GetAll() {
            var entityList = _context.Contacts.ToList();
            var modelList = new List<Contact>();
            foreach (var entity in entityList)
            {

            }
            return modelList;
        }

        public Contact GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Contact Update(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
