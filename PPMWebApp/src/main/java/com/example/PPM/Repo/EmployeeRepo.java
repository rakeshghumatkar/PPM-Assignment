package com.example.PPM.Repo;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.example.PPM.Model.Employee;

@Repository
public interface EmployeeRepo extends JpaRepository<Employee, Integer>
{

}
