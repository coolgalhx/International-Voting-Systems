using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;





namespace International_Voting_Systems
{


    public sealed class DataRetension
    {
        // The DataRetension's constructor should always be private to prevent
        // direct construction calls with the `new` operator.
        private DataRetension() { }

        // The DataRetension's instance is stored in a static field. There there are
        // multiple ways to initialize this field, all of them have various pros
        // and cons. In this example we'll show the simplest of these ways,
        // which, however, doesn't work really well in multithreaded program.
        private static DataRetension _instance;

        // This is the static method that controls the access to the singleton
        // instance. On the first run, it creates a singleton object and places
        // it into the static field. On subsequent runs, it returns the client
        // existing object stored in the static field.
        public static DataRetension GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataRetension();
            }
            return _instance;
        }

        // Finally, any singleton should define some business logic, which can
        // be executed on its instance.
        public void DeleteVoterTable()
        {
            using var context = new MainDatabaseContext();

            context.Database.ExecuteSqlRaw("DELETE FROM Voters");
        }


    }


}

