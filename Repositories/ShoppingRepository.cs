using ShoppingList.Data;
using ShoppingList.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;



namespace ShoppingList.Repositories


{
    public class ShoppingRepository
    {
        private readonly AppDbContext _context;

        public ShoppingRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<ShoppingItem> GetAll()//Get all shopping items from the database
        {
            return _context.ShoppingItems.ToList();
        }   
        public ShoppingItem GetById(int id)//Get a shopping item by its ID from the database
        {
            return _context.ShoppingItems.Find(id);
        }
        public ShoppingItem Add(ShoppingItem item)//Add a new shopping item to the database
        {
            _context.ShoppingItems.Add(item);
            _context.SaveChanges();
            return item;
        }
        public ShoppingItem Remove(int id)//Remove a shopping item by its ID from the database
        {
            var item = _context.ShoppingItems.Find(id);
            if (item != null)
            {
                _context.ShoppingItems.Remove(item);
                _context.SaveChanges();
            }
            return item;
        }
        public ShoppingItem Update(ShoppingItem item)//Update an existing shopping item in the database
        {
            _context.ShoppingItems.Update(item);
            _context.SaveChanges();
            return item;
        }


    }
}
    

