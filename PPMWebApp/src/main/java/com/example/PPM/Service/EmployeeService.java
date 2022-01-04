package com.example.PPM.Service;

import java.util.List;

import com.example.PPM.Model.Employee;

public interface EmployeeService
{
	public List<Employee> Get();
	
	public void Save(Employee employee);
	
	public Employee GetEmployeeById(int id);
	
	public Employee GetEmployeeById1(int id);
	
	public void DeleteById(int id);
}
