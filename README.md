
![Xtrade Logo](https://raw.githubusercontent.com/kiranhsgithub/xtrade/master/xtrade/xtrade/Content/XTLogo.png)
# XTrade 
   _*Trading made easy*_

## Welcome to XTrade app!
XTrade is a trading platform which can help people buy and sell anything without any hassles. Users can post their ad's, search for and browse various products and buy whatever they like via our app. We have implemented this via ASP.Net MVC framework. We have used various web API's and web services in this project. 

## Business blueprint
### Core Functionality
* Users can browse the products available without logging in. 
* Users can search for the items by entering the key words in the search bar. 
* If a person wants to buy or sell an item, he needs to log-in. 
* After logging in, seller can see his own list of items in a separate page, along with all the items for sale, in another page.
* User can register using his email-ID or he can login via google. Google + API has been used for this functionality.
* After logging in, if user faces any problems or if he has any complaints, he can go to the contact page and register a complaint. An automated Email is sent from the company's google account and all the messages are reviewed by XTrade customer care.
* Sellers can add/edit and delete the products. They can also Add/Edit and Delete multiple images for each of their product listings.
* Buyers bid on the sale price set by the seller. Seller reviews all the bids and contacts the person who ever offered him the best bid.
* In case the sale with this highest bidder fails due to some reason, the seller has an option to contact the next best bidder.
* Buyers and Sellers can chat with each other within the application.
The following diagram explains the business process.
![Xtrade Logo](https://raw.githubusercontent.com/kiranhsgithub/xtrade/master/BP.png)

### Technical Design



## Target Audience
The main target audience are people who want to sell their goods. Our application is seller driven as most of the control is in the hands of the seller. A seller can either accept or reject the bids of his prospective buyers. Our app also targets the people who want to sell their services, like cleaning service, laundry service etc. The sellers are also a main source of income for our business, which is explained in the monetization section

## Monetization
Our service is relatively new and there is a lot of competetion. So we are not aiming at generating any profits initially. However, for current and future purposes, the profits would be drawn from a paid functionality called as 'premium user'.
When a premium user posts an Ad, his ad is ranked at the top so that he can reach more number of prospective buyers. A small amount would be charged for premium users annually. They can make the payment via paypal or bank transfer.





# xtrade

Application which does following at minimum

* User shall be able to register
* User should be able to login
* User should be able to enter their Name, Email, Phone Number, address, Security Question to support forget password
* User should be able to post and add
* He should be able to enter item name, description, amount, Picture 
* User should be able to search items, View item details
* User should be able to buy and item 
* User (buyer) should be able to bargain and quote reduced price along with an optional message 
* User (seller) should be able to accept new (reduced) price or reject it along with an optional message 
* Seller should be able to chat with the buyer
* Both buyer and seller should be able to check whether the counter-party has read the message
