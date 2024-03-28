using BLL;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private UserBll userBll;

    public UserController(UserBll userBll)
    {
        this.userBll = userBll;
    }
    [Route("getuserbyid/{ID}")]
    [HttpGet]
    public User getUserByID(int ID)
    {
        return userBll.getUserByID(ID);

    }

    [Route("getallusers")]
    [HttpGet]
    public List<User> GetUsers()
    {
      return userBll.GetAllUsers();
    }

    [Route("update")]
    [HttpPost]
    public bool Update(User user)
    {
        return userBll.Update(user);
    }
    [Route("delete")]   
    [HttpPost]
    public bool DeleteUser([FromQuery] int userID)
    {
        return userBll.DeleteUser(userID);
    }
    [Route("adduser")]
    [HttpPost]
    public bool AddUser(User user)
    {
        return userBll.AddUser(user);
    }
}
