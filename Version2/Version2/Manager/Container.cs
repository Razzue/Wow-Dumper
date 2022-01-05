namespace Version2.Manager
{
    internal class Container
    {
        internal List<_Class>? Classes;

        internal bool Save(string FileName)
        {
            try
            {
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        internal bool Load(string FileName)
        {
            try
            {
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
