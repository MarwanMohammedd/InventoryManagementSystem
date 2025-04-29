namespace InventoryManagmentSystem.Shared.APIResult;

public class Result<T> 
{
    public bool IsSuccess { get; init;}
    public bool IsFailure { get; init;} = false;
    public T? Data { get; init;}
    public string? Error { get; init;}
    public static Result<T> Success(T data) => new Result<T>() {Data = data , IsSuccess = true};
    public static Result<T> Failure(string error) => new Result<T>(){Error = error , IsFailure = true};
}
