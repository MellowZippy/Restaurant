using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


//This class is not static so later on we can use inheritance and interfaces
public class AccountsLogic
{
    public static List<AccountModel> _accounts;

    //Static properties are shared across all instances of the class
    //This can be used to get the current logged in account from anywhere in the program
    //private set, so this can only be set by the class itself
    static public AccountModel? CurrentAccount { get; private set; }

    public AccountsLogic()
    {
        _accounts = AccountsAccess.LoadAll();
    }

    public static void RearrangeIDs()
    {
        int i = 0;

        foreach (AccountModel account in _accounts)
        {
            i++;
            account.Id = i;

            AccountsAccess.WriteAll(_accounts);
        }
    }


    public static void SetCurrentAccount(AccountModel acc) => CurrentAccount = acc;

    public void UpdateList(AccountModel acc)
    {
        //Find if there is already an model with the same id
        int index = _accounts.FindIndex(s => s.Id == acc.Id);

        if (index != -1)
        {
            //update existing model
            _accounts[index] = acc;
        }
        else
        {
            //add new model
            _accounts.Add(acc);
        }
        AccountsAccess.WriteAll(_accounts);

    }

    public AccountModel GetById(int id)
    {
        return _accounts.Find(i => i.Id == id)!;
    }

    public static AccountModel CheckLogin(string email, string password)
    {
        if (email == null || password == null)
        {
            return null!;
        }
        List<AccountModel> accounts = AccountsAccess.LoadAll();
        CurrentAccount = accounts.Find(i => i.EmailAddress == email && i.Password == password);
        return CurrentAccount!;
    }

    public static AccountModel AddAccount(string email, string password, string fullName, bool isAdmin, bool isWaiter, bool isCustomer)
    {
        List<AccountModel> accountsList = AccountsAccess.LoadAll();
        int nextId = accountsList.Count + 1;
        AccountModel acc = new AccountModel(nextId, email, password, fullName, isAdmin, isWaiter, isCustomer);
        accountsList.Add(acc);
        CurrentAccount = acc;
        AccountsAccess.WriteAll(accountsList);
        return acc;
    }

    public static bool CheckIfEmailExists(string email)
    {
        List<AccountModel> accountsList = AccountsAccess.LoadAll();
        AccountModel acc = accountsList.Find(i => i.EmailAddress == email)!;
        if (acc != null) return true;
        return false;
    }
}




