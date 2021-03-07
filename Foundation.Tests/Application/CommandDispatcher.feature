Feature: Command dispatcher

Scenario: Give objects that are not handlers
    Given a developer had a collection of objects that are not handlers
    When a developer creates a command dispatcher from the collection
    Then calling the constructor will throw an argument exception

Scenario: Give two handlers for the same command
    Given a developer had a collection of two handlers for the same command
    When a developer creates a command dispatcher from the collection
    Then calling the constructor will throw an argument exception

Scenario: Give a handler for a command
    Given a developer had a collection of one single handler
    And a developer had a command
    When a developer creates a command dispatcher from the collection
    Then calling the constructor will create the command dispatcher
    And dispatching the command will call the handler