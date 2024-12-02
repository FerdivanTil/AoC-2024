namespace Businesslogic.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class FileNameAttribute(string fileName) : Attribute
    {
        public string FileName { get; set; } = fileName;
    }
}
