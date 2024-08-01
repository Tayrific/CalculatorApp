using System;
using System.Configuration; 
using System.Data.Entity; 

namespace CalculatorApi
{
    public class EFDiagnostics : IDiagnostics
    {
        private readonly CalcLogDBEntities _context;

        public EFDiagnostics()
        {
            // Initialize DbContext with the connection string from App.config
            _context = new CalcLogDBEntities(); // Default constructor uses connection string from App.config
        }

        public void Log(string message)
        {
            try
            {
                var log = new Log
                {
                    Message = message,
                    LogDate = DateTime.Now
                };
                _context.Logs.Add(log);
                _context.SaveChanges();               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving the log: {ex.Message}");
            }
        }
    }
}

