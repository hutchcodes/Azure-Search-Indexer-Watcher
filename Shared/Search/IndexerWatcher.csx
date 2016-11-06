#r "SendGrid"
#load "../Settings.csx"

using System;
using SendGrid.Helpers.Mail;
using Microsoft.Azure.Search;

public static class IndexerWatcher {

    public static Mail GetFailureNotification(string searchService, string searchIndexer, TraceWriter log)
    {
        var apiKey = Settings.GetSetting("SearchApiKey");
        log.Info(apiKey);
        string body = "";

        var client = new SearchServiceClient(searchService, new SearchCredentials(apiKey));

        var status = client.Indexers.GetStatus(searchIndexer);

        foreach (var hist in status.ExecutionHistory)
        {
            if (hist.EndTime > DateTime.UtcNow.AddMinutes(-65) && !string.IsNullOrWhiteSpace(hist.ErrorMessage))
            {
                body += hist.ErrorMessage + Environment.NewLine;
            }
        }

        Mail message = null;
        if (!string.IsNullOrEmpty(body))
        {
            message = new Mail();

            Content content = new Content
            {
                Type = "text/plain",
                Value = body
            };

            message.AddContent(content);
        }
        return message;
    }
}