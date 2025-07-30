namespace SmartStore.Models.Dtos.Users.Requests;

public sealed record RegisterRequest(string FirstName, string LastName, string Email, string Password, string Username, string City);
