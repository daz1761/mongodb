using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDBDemo
{
    class Code
    {
        //PersonModel person = new PersonModel()
        //{
        //    FirstName = "Joe",
        //    LastName = "Smith",
        //    PrimaryAddress = new AddressModel()
        //    {
        //        StreetAddress = "3 Ainsdale Grove",
        //        City = "Wrexham",
        //        State = "Denbighshire",
        //        ZipCode = "LL12 7TJ"
        //    }
        //};

        // we dont need an ID as Mongo will create one for us (insert or update if we provide one)
        //db.InsertRecord<PersonModel>("Users", person); 


        // like SELECT * FROM ...
    //    var records = db.LoadRecords<PersonModel>("Users");

    //        foreach(var rec in records)
    //        {
    //            Console.WriteLine($"{rec.Id}: {rec.FirstName} {rec.LastName}");

    //            if(rec.PrimaryAddress != null)
    //            {
    //                Console.WriteLine($"{rec.PrimaryAddress.City}");
    //            }
    //Console.WriteLine();
    //        }
    }
}
