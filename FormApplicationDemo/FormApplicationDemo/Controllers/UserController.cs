using Microsoft.AspNetCore.Mvc;
using FormApplicationDemo.Models;
namespace FormApplicationDemo.Controllers;

[Route("register")]
public class UserController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [Route("getUsers")]
    [HttpPost]
    public IActionResult GetUsers(UserModel input)
    {
        List<UserModel> user = getUser(input);
        return View(user);
    }


    private List<UserModel> getUser(UserModel input)
    {
        List<UserModel> userModels = new List<UserModel>();
        var user1 = new UserModel();
        user1.FirstName = "Bharat";
        user1.LastName = "Varshan";
        user1.Age = 22;

        var user2 = new UserModel();
        user2.FirstName = "Sam";
        user2.LastName = "Anderson";
        user2.Age = 25;
        var user3 = new UserModel();
        user3.FirstName = "Tom";
        user3.LastName = "Holland";
        user3.Age = 33;

        userModels.Add(user1);
        userModels.Add(user2);
        userModels.Add(user3);
        
        if (input != null)
        {


            userModels.Add(addUser(input));
        }
        return userModels;
    }
    private UserModel addUser(UserModel input)
    {

        var user = new UserModel();
        user.FirstName = input.FirstName;
        user.LastName = input.LastName;
        user.Age = input.Age;

        return user;

    }
}



