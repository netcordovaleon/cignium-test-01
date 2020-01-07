# CIGNIUM TEST

You can find the .exe in: SearchFightCignium\SearchFight.Run\bin\Release>SearchFight.Run.exe

# Consideration:

Keys for Google and Bing services are in SearchFight.Core\SearchFightConstants

- Google API: https://www.googleapis.com/customsearch/v1?key={TOKEN}&cx=017576662512468239146:omuauf_lfve&q=

- Bing API: https://api.cognitive.microsoft.com/bing/v7.0/search?q= 

*Bing Key valid for 7 days (start day: 05/01/2019)

# EXAMPLE:
    SearchFight.Run.exe java .net "ecma script"
	
	java Google Search: 1100000000 Bing Search: 83500000
	.net Google Search: 18260000000 Bing Search: 77800000
	ecma script Google Search: 7 Bing Search: 2570000
	Google Winner: .net
	Bing Winner: java
	TOTAL Winner: .net
		