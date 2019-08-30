using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BlueYonder.DataAccess.Interfaces;
using BlueYonder.Entities;

namespace BlueYonder.DataAccess.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        TravelCompanionContext context;

        public ReservationRepository(string connectionName)
        {
            context = new TravelCompanionContext(connectionName);
        }

        public ReservationRepository()
        {
            context = new TravelCompanionContext();
        }

        public ReservationRepository(TravelCompanionContext dbContext)
        {
            context = dbContext;
        }

        public Reservation GetSingle(int entityKey)
        {
            //TODO :Lab 02 Exercise 1, Task 4.2 : Implement the GetSingle Method
            return null;
        }

        //TODO :Lab 02 Exercise 1, Task 4.5 : implement the GetAll Method
        public IQueryable<Reservation> GetAll()
        {             
            return null;
        }

        public IQueryable<Reservation> FindBy(Expression<Func<Reservation, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        //TODO :Lab 02 Exercise 1, Task 4.5 : implement the Add Method

        public void Add(Reservation entity)
        {
        }

        //TODO :Lab 02 Exercise 1, Task 4.5 : implement the Delete Method
        public void Delete(Reservation entity)
        {
        }

        public void Edit(Reservation entity)
        {
            //TODO :Lab 02 Exercise 1, Task 4.3 : Implement the Edit Method
        }

        public void Save()
        {
            context.SaveChanges();
        }
        
        public void Dispose()
        {
            //TODO :Lab 02 Exercise 1, Task 4.4 : Implement the Dispose Method        
        }
       
    }
}
