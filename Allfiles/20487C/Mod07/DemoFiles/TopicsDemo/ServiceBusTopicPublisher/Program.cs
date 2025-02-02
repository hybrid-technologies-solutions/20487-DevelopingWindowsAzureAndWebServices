﻿using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusTopicPublisher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Purchases Publisher";
            Console.WriteLine("Verifying existence of Service Bus Topic and Subscriptions");
            // Creating the topic if it does not exist already using the service bus connection string stored in the app.config file
            string connectionString =
                ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"];

            var namespaceManager =
                NamespaceManager.CreateFromConnectionString(connectionString);

            // Making sure that the topic exists
            if (!namespaceManager.TopicExists("productsalestopic"))
            {
                namespaceManager.CreateTopic("productsalestopic");
            }

            // Making sure that the subscriptions exists
            if (!namespaceManager.SubscriptionExists("productsalestopic", "AllPurchases"))
            { 
                // Create a "Audit" subscription
                namespaceManager.CreateSubscription("productsalestopic",
                   "AllPurchases");
            }

            if (!namespaceManager.SubscriptionExists("productsalestopic", "ExpensivePurchases"))
            {
                // Create a "ExpensivePurchases" filtered subscription
                SqlFilter ExpensivePurchasesFilter =
                   new SqlFilter("ProductPrice > 4000");

                namespaceManager.CreateSubscription("productsalestopic",
                   "ExpensivePurchases",
                   ExpensivePurchasesFilter);
            }

            if (!namespaceManager.SubscriptionExists("productsalestopic", "CheapPurchases"))
            {
                // Create a "CheapPurchases" filtered subscription
                SqlFilter CheapPurchasesFilter =
                   new SqlFilter("ProductPrice <= 4000");

                namespaceManager.CreateSubscription("productsalestopic",
                   "CheapPurchases",
                   CheapPurchasesFilter);
            }

            Console.WriteLine("Press any key to start publishing messages.");
            Console.ReadKey();

            Console.WriteLine("Sending four messages");
            // Creating four messages for publishing - two with price below 4000$, and two with price above 4000$
            var ShoesMessage = new BrokeredMessage();
            ShoesMessage.Properties["ProductId"] = 1;
            ShoesMessage.Properties["ProductName"] = "Shoes";
            ShoesMessage.Properties["ProductPrice"] = 2000;

            var PantsMessage = new BrokeredMessage();
            PantsMessage.Properties["ProductId"] = 2;
            PantsMessage.Properties["ProductName"] = "Pants";
            PantsMessage.Properties["ProductPrice"] = 5000;

            var ShirtMessage = new BrokeredMessage();
            ShirtMessage.Properties["ProductId"] = 3;
            ShirtMessage.Properties["ProductName"] = "Shirt";
            ShirtMessage.Properties["ProductPrice"] = 3000;

            var JacketMessage = new BrokeredMessage();
            JacketMessage.Properties["ProductId"] = 4;
            JacketMessage.Properties["ProductName"] = "Jacket";
            JacketMessage.Properties["ProductPrice"] = 6000;

            TopicClient topicClient = TopicClient.Create("productsalestopic");

            // Sending the messages to service bus
            Console.WriteLine("Press enter to send shoes (2k$)");
            Console.ReadLine();
            topicClient.Send(ShoesMessage);
            Console.WriteLine("Press enter to send pants (5k$)");
            Console.ReadLine();
            topicClient.Send(PantsMessage);
            Console.WriteLine("Press enter to send shirt (3k$)");
            Console.ReadLine();
            topicClient.Send(ShirtMessage);
            Console.WriteLine("Press enter to send shirt (6k$)");
            Console.ReadLine();
            topicClient.Send(JacketMessage);

            Console.WriteLine("Sending complete");            
        }
    }
}
