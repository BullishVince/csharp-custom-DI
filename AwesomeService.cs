public interface IAwesomeService {
    public string GetText();
}

public class AwesomeService : IAwesomeService
{
    public string GetText() => "Lorem Ipsum Dolor Sit Amet";
}