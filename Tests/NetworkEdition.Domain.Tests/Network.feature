Feature: Network

Scenario: Create a network
    Given a Guid
    When creating a network
    Then should work

Scenario: Add a relay to a network
    Given a network
    When adding a relay
    Then should contain the relay