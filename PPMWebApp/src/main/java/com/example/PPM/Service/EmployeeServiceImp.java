package com.example.PPM.Service;

import java.util.List;
import java.util.Optional;

import javax.management.RuntimeErrorException;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.PPM.Model.Employee;
import com.example.PPM.Repo.EmployeeRepo;


@Service
public class EmployeeServiceImp implements EmployeeService
{
	@Autowired
	private EmployeeRepo repo;

	@Override
	public List<Employee> Get() {
		
		return repo.findAll();
	}

	@Override
	public void Save(Employee employee) {
		repo.save(employee);
	}

	@Override
	public Employee GetEmployeeById(int id) {
		Optional<Employee> optional = repo.findById(id);
		Employee employee = null;
		if(optional.isPresent())
		{
			employee = optional.get();
		}
		else
		{
			throw new RuntimeException("Employee not found for id : "+id);
		}
		return employee;
	}
	
	public Employee GetEmployeeById1(int id) {
		Optional<Employee> optional = Optional.of(repo.getById(id));
		Employee employee = null;
		if(optional.isPresent())
		{
			employee = optional.get();
		}
		else
		{
			throw new RuntimeException("Employee not found for id : "+id);
		}
		return employee;
	}


	@Override
	public void DeleteById(int id) {
		repo.deleteById(id);
	}

}
