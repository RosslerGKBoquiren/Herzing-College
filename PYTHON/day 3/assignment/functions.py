def sort_name(firstname, lastname, sortorder="firstlast"):
    if sortorder == "firstlast":
        print(firstname + " " + lastname)
    elif sortorder == "lastfirst":
        print(lastname + ", " + firstname)
    else:
        print("Error sort order")

# Ask the user for first and last name
firstname = input("Enter your first name: ")
lastname = input("Enter your last name: ")

# Call default function sort order ("firstlast")
sort_name(firstname, lastname)

# Call alternative function sort order "lastfirst"
sort_name(firstname, lastname, sortorder="lastfirst")
