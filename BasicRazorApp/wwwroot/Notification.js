//import { signalR } from "./lib/aspnet-signalr/signalr";

//let connection = null;

let connection = new signalR.HubConnectionBuilder()
    .withUrl("/razorhub")
    .build();

connection.on("RecieveRestaurant", (update) => {
    debugger;
    const statusDiv = document.getElementById("pushnotify");
    statusDiv.innerHTML = update;
}
);

connection.start().
    catch(err => console.log(err));

window.onload = function () {
    fetch("/api/Restaurants/pushup",
        {
            method: "GET",
            headers: {
                'content-type': 'application/json'
            }
        })
        .then(response => response.text())
        .then(id => connection.invoke("TotalRestaurantCount"));
    debugger;
}