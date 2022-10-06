"""Retrieve and print words from an url.

Usage:
    python words.py <url>
"""

import sys
from urllib.request import urlopen

def fech_words(url):
    """Fetch a list of words from an URL

    Args:
        url: The url of the UTF-8 document

    Returns:
        a list a string containing the words from the document

    """
    story = urlopen(url)
    story_word=[]
    for line in story:
        line_words= line.decode('utf-8').split()
        for word in line_words:
            story_word.append(word)
    story.close()

    return story_word

def print_items(items):
    """Print item from a list of items, one per line

    Args:
        items: array of object
    """

    for item in items:
        print (item)

def get_list_country():
    """Return the list of coutntries"""

    countries=[]
    countries.append('france')
    countries.append('ireland')

    return countries

def countCountries(countries,listOfWords):
    d= dict()

    for word in listOfWords:
        if word in countries:
            if word not in d:
                d[word]=1
            else:
                d[word]+=1
    
    for country, numbers  in d.items():
        print (country, numbers)


    
def main(url):
    """Print each words from text document from at a url

    Args:
        url: the url of the UTF-8 document 
    """
    
    words= fech_words(url)
    countries= get_list_country()

    words.append('france')
    words.append('france')
    words.append('ireland')
    

    countCountries(countries,words)
    #print_items(words)

if __name__== '__main__':
    url="http://sixty-north.com/c/t.txt"
    main(url)