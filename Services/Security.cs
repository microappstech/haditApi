namespace haditApi.Services
{
    public class Security
    {
        private dbContext dbContext;
        public Security(dbContext dbContext)
        {
            this
                .dbContext = dbContext;
        }
        public bool CheckKey(string key)
        {
                var exist = this.dbContext.Keys.Where(i => i.KeyValue == key).Any();
            return exist;
        }
    }
}
