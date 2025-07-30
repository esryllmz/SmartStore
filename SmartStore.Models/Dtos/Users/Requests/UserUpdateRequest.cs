namespace SmartStore.Models.Dtos.Users.Requests;

public sealed record UserUpdateRequest(string FirstName, string LastName, string City, string Username);
