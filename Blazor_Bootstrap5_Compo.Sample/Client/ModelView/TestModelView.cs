using Blazor_Bootstrap5_Compo.Form;

namespace Blazor_Bootstrap5_Compo.Sample.Client.ModelView
{

    public class View
    {
        public string ValueCompo1 { get; set; } = string.Empty;
        public string ValueCompo2 { get; set; } = "15.09.1999";
        public int ValueCompo3 { get; set; } = 1;
        public string ValueCompo5 { get; set; } = string.Empty;


        //Same object is used but it is not the case in reallity
        public List<ColObjectTest> Collection = new() {
        new ColObjectTest() {Id = 1, Value = "Value 1", IsChecked = true },
        new ColObjectTest() {Id = 2, Value = "Value 2", IsChecked = false },
        new ColObjectTest() {Id = 3, Value = "Value 3", IsChecked = true}};
    }

    public class ColObjectTest
    {
        public int Id { get; set; } = 1;
        public string Value { get; set; } = "Value Test";
        //used for multiple checkbox col
        public bool IsChecked { get; set; } = false;
    }
}
