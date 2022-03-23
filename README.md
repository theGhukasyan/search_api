# search_api

I was working on Search API, by trying to demonstrate how the service architecture should look like, as well as the relations between the entities.
According to requirement, the relation between two entities are one-to-many (one individual may have multiple contracts).
To boost data reading performance, I was using AsNoTracking() method on every query.
Both tables are indexed (please check SearchAPI.Sql project).
As we consider that we're dealing with huge amount of data at the same time, there's no in-memory loading to avoid RAM's occupation.
Sadly I couldn't normally test it. The main purpose is to show the code style, architectural solutions and how the calls to db should be implemeneted.

Few remarks on what I had to do but couldn't because of lack of time:

1. In theory we should use caching for fast data retrieval. If XML loader (I didn't implement that, but bulk insert is needed for importing 50GB of data) could give our service the new incoming contracts, we could cash their ids (or for better performance their customerCodes). 
2. By having those ids in cache, we could calculate the approximate count of records and make batch calls to database via multithreading which would not affect on memory significantly, but would give us much better execution time.
3. The exception handling should be implemeneted via Exception handling middleware, where we're carrying for endpoints behaviour based on exception types.
4. One of the ways to use yield if service's responsiveness is important from the caller-perspective.
5. If we know how the windows service (responsible for bulk inserting xml data) schedule time, we could make partitioning based on the time interval specified in the columns.
6. Oracle DB has BULK COLLECT which to my understanding is one of the best solutions when it comes to collecting big data in relational databases.
