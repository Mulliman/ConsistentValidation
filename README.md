Consistent Validation
=====================

Most projects require values to be validated and there are plenty of frameworks in place to help, but even with these in place it can be tedious and time consuming. Most of the time seems to be spent discussing what the rules should be rather than actually writing code.

This library's aim is to provide a set of validation rules that can be reused from project to project, without having to re-evaluate what the criteria should be. The messages that are shown for each error should also be unified but editable so that a content editor can edit them in one place.

This is currently in initial development.

Rules
-----

### The rules currently implemented are:

#### Dates

- DateInFutureRule
- DateInPastRule
- DayOfWeekRule
- DayRule
- MonthRule
- Year4DigitRule
- YearCurrentOrInFutureRule
- YearCurrentOrInPastRule
- YearInFutureRule
- YearInPastRule
- DateAfterRule
- DateBeforeRule
- DateInbetweenRule

#### Financial

- CardSecurityCodeRule

Connectors
----------

#### Sitecore 

~ In development ~

https://github.com/Mulliman/ConsistentValidation-Sitecore

#### Umbraco

~ In development ~

https://github.com/Mulliman/ConsistentValidation-Umbraco