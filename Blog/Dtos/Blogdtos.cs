namespace Company.ClassLibrary1;

public record Blogdtos(
    int ID,
    string title,
    string content,
    string category,
    DateOnly releaseDate
);
