using Grpc.Core;
using GrpcCustomersService;
using DataAccess = Miroșnicenco_Eugenia_Lab2.Data;
using ModelAccess = Miroșnicenco_Eugenia_Lab2.Models;

namespace GrpcCustomersService.Services
{
    public class GrpcCRUDService : CustomerService.CustomerServiceBase
    {

        private DataAccess.Miroșnicenco_Eugenia_Lab2Context db = null;
        public GrpcCRUDService(DataAccess.Miroșnicenco_Eugenia_Lab2Context db)
        {
            this.db = db;
        }
        public override Task<CustomerList> GetAll(Empty empty, ServerCallContext
       context)
        {

            CustomerList pl = new CustomerList();
            var query = from cust in db.Customer
                        select new Customer()
                        {
                            CustomerId = cust.CustomerID,
                            Name = cust.Name,
                            Adress = cust.Adress,
                            Birthdate = cust.BirthDate.ToString("yyyy-MM-dd")
                        };
            pl.Item.AddRange(query.ToArray());
            return Task.FromResult(pl);
        }
        public override Task<Empty> Insert(Customer requestData, ServerCallContext context)
        {
            db.Customer.Add(new ModelAccess.Customer
            {
                //CustomerID = requestData.CustomerId,
                Name = requestData.Name,
                Adress = requestData.Adress,
                BirthDate = DateTime.Parse(requestData.Birthdate)
            });
            db.SaveChanges();
            return Task.FromResult(new Empty());
        }
        public override Task<Customer> Get(CustomerId requestData, ServerCallContext context)
        {
            var data = db.Customer.Find(requestData.Id);

            Customer emp = new Customer()
            {
                CustomerId = data.CustomerID,
                Name = data.Name,
                Adress = data.Adress,
                Birthdate = data.BirthDate.ToString("yyyy-MM-dd")

            };
            return Task.FromResult(emp);
        }

        public override Task<Empty> Delete(CustomerId requestData, ServerCallContext context)
        {
            var data = db.Customer.Find(requestData.Id);
            db.Customer.Remove(data);

            db.SaveChanges();
            return Task.FromResult(new Empty());
        }

        public override Task<Customer> Update(Customer requestData, ServerCallContext context)
        {
            var data = db.Customer.Find(requestData.CustomerId);

            if (data == null)
                return Task.FromResult<Customer>(null);

            data.Name = requestData.Name;
            data.Adress = requestData.Adress;
            data.BirthDate = DateTime.Parse(requestData.Birthdate);

            db.SaveChanges();

            var updatedCustomer = new Customer()
            {
                CustomerId = data.CustomerID,
                Name = data.Name,
                Adress = data.Adress,
                Birthdate = data.BirthDate.ToString("yyyy-MM-dd")
            };

            return Task.FromResult(updatedCustomer);
        }

    }
}
