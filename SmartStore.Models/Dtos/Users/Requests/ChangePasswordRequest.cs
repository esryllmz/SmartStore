namespace SmartStore.Models.Dtos.Users.Requests;

public sealed record ChangePasswordRequest(string CurrentPassword, string NewPassword, string ConfirmNewPassword);
