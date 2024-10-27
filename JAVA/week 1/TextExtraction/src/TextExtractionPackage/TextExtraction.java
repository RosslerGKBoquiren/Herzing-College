package TextExtractionPackage;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class TextExtraction {

	public static void main(String[] args) {
		
		String url = "https://www.example.com/page";
		String tweet = "Excited to announce our new product #launch! #exciting #newbeginnings";
		String sentence = "The quick brown fox jumps over the lazy dog";

		System.out.printf("\nExtracted Domain: %s", extractDomain(url));
		System.out.printf("\n\nExtracted tweet with no hashtags: %s", extractHashtag(tweet));
		System.out.printf("\n\nExtracted last word: %s", extractLastWord(sentence));
		
	}
	
	// Method to extract the domain name from a given URL using 'substring' and 'indexOf'
	public static String extractDomain(String url) {
		
		int startIndex;
		int endIndex;
		
		// determine if the starting index is based on 'www.' or '//' in the URL
		if(url.indexOf("www.") >= 0) {
			startIndex = url.indexOf("www.") + 4;
		} else {
			startIndex = url.indexOf("//") + 2;
		}
		
		// find the position of the first '/' after the domain to determine the end index
		endIndex = url.indexOf("/", startIndex);
		
	    return url.substring(startIndex, endIndex);
	   
	}
	
	
	// Method to remove the hashtags and retrieve the tweet using regular expressions
	public static String extractHashtag(String tweet) {
		
		// create a Matcher to find all the words that has a '#'
		Matcher matcher = Pattern.compile("#(\\w+)").matcher(tweet);
		StringBuilder noHashtag = new StringBuilder();
		
		// iterate over all the matches and append them to noHasthtag StringBuilder
		while (matcher.find()) {
			if (noHashtag.length() > 0) {
				noHashtag.append(", ");
			}
			noHashtag.append(matcher.group(1));
		}
		return noHashtag.toString();
		
	}
	
	// Method to extract the last word from a sentence using regular expression
	public static String extractLastWord(String sentence) {
		
		// create a matcher to find the last word in the sentence
		Matcher matcher = Pattern.compile("\\b(\\w+)$").matcher(sentence);
		
		// return the last word if found, it not return an empty string
		if (matcher.find()) {
            return matcher.group(1);
        } else {
            return "";
        }
		
	}
	
}
