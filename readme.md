# Azure Search Indexer Watcher

Since there is nothing built into the Azure Search Indexers to notify in the event of a failure I've built this simple Azure Function that will watch the Indexer Status and email me if the Indexer fails.

It runs hourly and looks back at 65 minutes of status just to be sure it didn't miss anything.

You'll need to update the following settings to get it to work.

- In the `IndexWatcher_Env/run.csx` you need to put in the name of your search service and search indexer

- In the `IndexWatcher_Env/function.json` you'll need to enter your from and to email addresses in the `SendGrid` binding section.

- From the Portal you'll need to add the following app setting keys with their appropriate values
	- SendGridApiKey
	- SearchApiKey



