// SPDX-License-Identifier: MIT
pragma solidity ^0.8.7;

contract SimpleStorage {
    string private _storedData;

    function set(string memory x) public {
        _storedData = x;
    }

    function get() public view returns (string memory) {
        return _storedData;
    }
}
