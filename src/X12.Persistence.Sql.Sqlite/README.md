#Work in Progress

Ideally the Persistence has been abstracted enough to be store agnostic and so 
eventually I hope to SQLite implemented. SQLite should be beneficial for smaller
shops that do not necessarily require the overhead of full SQL install but also
to greatly facilite test writing and eventually reproducing bugs that can also be 
verified via unit tests.

#Pull Requests are Welcomed

But please be aware testing is currently my number one priority for this project
as it originally had very little / fragile tests. So do not bother with a pull 
request unless it is adequately covered with tests.