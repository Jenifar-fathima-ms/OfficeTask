## Weekend Task - 04
### Command Simulation

- You're given a list of file system commands like cd, pwd, and a simplified simulation of directory navigation.

- Your task is to simulate the file system traversal and respond to pwd commands with the current absolute path.

Input Format:
 ```
    
      - cd <path>: Changes the current directory.
            <path> can be:
                - an absolute path (starts with /)
                - a relative path (e.g., .., folder/../dir)
      - pwd: Prints the current working directory
```
Implement a method that takes a list of strings (commands) and outputs the result of all pwd commands.

### Example:
### Test Case - I:
Input:
```
            [
                "cd /home",
                "cd user",
                "pwd",
                "cd ..",
                "pwd",
                "cd ./projects/../code",
                "pwd"
            ]
```
Output:
```
            [
                "/home/user/",
                "/home/",
                "/home/code/"
            ]
```

### Test Case - II:
Input:
```
           [
                "cd /",
                "cd home",
                "cd ./user//",
                "cd ../..",
                "cd ../..",
                "cd var/log",
                "pwd",
                "cd /etc/./nginx/../ssh",
                "pwd",
                "cd ..",
                "pwd"
            ]
```
Output:
```
            [
                "/var/log/",
                "/etc/ssh/",
                "/etc/"
            ]
```