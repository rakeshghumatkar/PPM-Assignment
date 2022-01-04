package com.example.PPM.Controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;

import com.example.PPM.Model.Role;
import com.example.PPM.Service.RoleService;

@Controller
public class RoleController 
{
	@Autowired
	private RoleService service;
	
	@GetMapping("/roles")
	public String getRoles(Model model)
	{
		model.addAttribute("Rolelist", service.Get());
		return "role_index";
	}
	
	@PostMapping("/saveRole")
	public String saveRole(@ModelAttribute("role") Role role)
	{
		service.Save(role);
		return "redirect:/roles";
	}
	
	@GetMapping("/showNewRoleForm")
	public String showNewRoleForm(Model model)
	{
		Role role = new Role();
		model.addAttribute("role", role);
		return "new_role";
	}
	
	@GetMapping("/showUpdateRoleForm/{id}")
	public String showUpdateRoleForm(@PathVariable(value ="id") int id, Model model)
	{
		Role role = service.GetById(id);
		model.addAttribute("role", role);
		return "new_role";
	}
	
	@GetMapping("deleteRole/{id}")
	public String deleteRole(@PathVariable(value ="id") int id)
	{
		service.Delete(id);
		return "redirect:/roles";
	}
	

}
