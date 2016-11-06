#r "SendGrid"
#load "../Shared/Search/IndexerWatcher.csx"

using SendGrid.Helpers.Mail;

public static void IndexWatcher_Stage(TimerInfo myTimer, TraceWriter log, out Mail message)
{
    var searchService = "mySearchService";
    var searchIndexer = "myBlobIndexer";

    message = IndexerWatcher.GetFailureNotification(searchService, searchIndexer, log);
}
