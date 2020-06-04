using BasicRazorApp.Data;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicRazorApp.RazorHubs
{
    public class RazorHub : Hub
    {
        private readonly IRestaurantData restaurantData;

        public RazorHub(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        //public async Task GetUpdateForOrder(int orderId)
        //{
        //    CheckResult result;
        //    do
        //    {
        //        result = _orderChecker.GetUpdate(orderId);
        //        Thread.Sleep(1000);
        //        if (result.New)
        //            await Clients.Caller.SendAsync("ReceiveOrderUpdate",
        //                result.Update);
        //    } while (!result.Finished);
        //    await Clients.Caller.SendAsync("Finished");
        //}

        public async Task TotalRestaurantCount()
        {
            var count = restaurantData.GetCountOfRestaurants();
            await Clients.All.SendAsync("RecieveRestaurant", count);
        }
    }
}