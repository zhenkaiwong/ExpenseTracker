# ExpenseTracker 

A repository for my personal project "Expenses Tracker" from roadmap.sh Backend Beginner roadmap

# How to use this?

1. Clone this project to local
2. Run the following commands

## Commands

### Adding a new task

```
dotnet run add --description "Food" --amount 2
```

### Updating and deleting expense

```
dotnet run update --id 1 --description "Western food"
dotnet run update --id 1 --amount 20
dotnet run update --id 1 --description "Chinese food" --amount 21 
dotnet run delete --id 1
```

### Summarize expenses 

```
dotnet run summary
dotnet run summary --month 1
```

### Listing all expenses

```
dotnet run list
```

# URL to this project
https://roadmap.sh/projects/expense-tracker