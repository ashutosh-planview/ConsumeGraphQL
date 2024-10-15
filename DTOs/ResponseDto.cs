namespace DTOs
{
  public class GraphQLResponseDto<T>
  {
    public T Data { get; set; }
    
    public GraphQLResponseDto(T data)
    {
      Data = data;
    }
  }

  public class PvadminDto<T>
  {
    public T Pvadmin_ { get; set; }

    public PvadminDto(T pvadmin_)
    {
      Pvadmin_ = pvadmin_;
    }
  }

  public class GetCurrentUserDto
  {
    public CurrentUser GetCurrentUser { get; set; }

    public GetCurrentUserDto(CurrentUser getCurrentUser)
    {
      GetCurrentUser = getCurrentUser;
    }
  }
}