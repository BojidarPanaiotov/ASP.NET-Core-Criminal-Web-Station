namespace Criminal_Web_Station
{
    public class WebConstats
    {
        //Type of message
        public const string Message = "Message";
        public const string Warning = "Worning";

        //User messages

        //Messages about items
        public const string ItemAddMessage = "Item has been added to the market. You can click on 'UserAdds' to see your items.";
        public const string ItemAddToShoppingCartMessage = " has been added to your shopping cart.";
        public const string ItemHasBeenAddedMessage = "This item has been added to your shopping cart. Cannot add it again.";
        public const string ItemHasBeenEdited = "Item has been edited.";
        public const string ItemHasBeenDeleted = "Item has been deleted";
        public const string ItemRemovedFromShoppingCart = " have been removed from the shopping cart.";
        public const string SuccessfulBoughtItems = "Succesful bought {0} items";
        public const string ItemOwnedMessage = "This item is yours. You cannot buy or add it to the shopping cart.";

        //Messages about credit card
        public const string SuccessfulCreditCardAdd = "You have successfully added your credit card.";
        public const string AlreadyAddedCreditCard = "You already added your credit card";
        public const string NotEnoughMoney = "You don't have enough money in your credit card.";
        public const string SuccessfulTransaction = "Transsaction was successful. ${0} has been added to your account.";
        public const string NoCreditCardAdded = "You don't have credit card. Please added one.";

        //Messages for users account
        public const string SuccessfulLogin = "Successful login.";
        public const string SuccessfulRegistration = "Successful registration.";
        public const string UserIsBannedInformation = "User: {0} is banned / Reason: {1} / Time: {2}";
        public const string UserBanInformation = "You are banned. Reason - {0} for {1} seconds";
    }
}
