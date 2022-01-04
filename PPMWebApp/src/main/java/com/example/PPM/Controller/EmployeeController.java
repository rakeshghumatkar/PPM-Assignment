package com.example.PPM.Controller;



import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;

import java.util.Date;
import java.sql.Timestamp;
import java.time.LocalDate;

import com.example.PPM.Model.Employee;
import com.example.PPM.Service.EmployeeService;
import com.example.PPM.Service.RoleService;

@Controller
public class EmployeeController
{
	@Autowired
	private EmployeeService service;
	
	@Autowired
	private RoleService roleservice;
	
	
	@GetMapping("/employees")
	public String Get(Model model)
	{
		model.addAttribute("Employeelist", service.Get());
		model.addAttribute("listRole", roleservice.Get());
		return "employee_index";
	}
	
	@GetMapping("/showNewEmployeeForm")
	public String showNewEmployeeForm(Model model)
	{
		Employee employee = new Employee();
		model.addAttribute("employee", employee);
		model.addAttribute("listRole", roleservice.Get());
		return "new_employee";
	}
	
	@PostMapping("/saveEmployee")
	public String saveEmployee(@ModelAttribute("employee") Employee employee)
	{
		if(employee.getCreateDate()==null)
		{
			employee.setCreateDate(LocalDate.now());
		}
		employee.setModifiedDate(LocalDate.now());
		service.Save(employee);
		return "redirect:/employees";
	}
	
	
	@GetMapping("/showFormForUpdate/{id}")
	public String showFormForUpdate(@PathVariable(value="id") int id, Model model)
	{
		Employee employee = service.GetEmployeeById(id);
		
		model.addAttribute("employee", employee);
		model.addAttribute("listRole", roleservice.Get());
		return "new_employee";
	}
	
	
	@GetMapping("/deleteEmployee/{id}")
	public String deleteEmployee(@PathVariable(value="id") int id)
	{
		service.DeleteById(id);
		return "redirect:/employees";
	}

}
