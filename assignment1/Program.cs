namespace assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            BatchProcessor batchProcessor = new BatchProcessor();

            batchProcessor.AddLoader(new CallDataLoader());
            batchProcessor.AddLoader(new TwitterDataLoader());
            batchProcessor.AddLoader(new SensorDataLoader());

            batchProcessor.ProcessBatch();
        }
    }
}