package com.example.PPM.Controller;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.stereotype.Service;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.servlet.ModelAndView;

import com.example.PPM.Model.Employee;
import com.example.PPM.Model.Project;
import com.example.PPM.Repo.ProjectRepo;
import com.example.PPM.Service.EmployeeService;
import com.example.PPM.Service.ProjectService;
import com.example.PPM.Service.ProjectServiceImp;


@Controller
public class ProjectController
{
	@Autowired
	private ProjectService service;
	
	@Autowired
	private EmployeeService employeeservice;
	
	@GetMapping("/")
	public String viewProjects()
	{
		return "home";
	}
	
	@GetMapping("/projects")
	public String viewProjects(Model model)
	{
		model.addAttribute("Projectlist",service.Get());
		return "project_index";
	}

	
	@PostMapping("/saveProject")
	public String saveProject(@ModelAttribute("project") Project project)
	{
		if(project.getCreateDate()==null)
		{
			project.setCreateDate(LocalDate.now());
		}
		project.setModifiedDate(LocalDate.now());
		service.Save(project);
		return "redirect:/projects";
	}
	
	@GetMapping("/newProjectForm")
	public String newProjectForm(Model model)
	{
		Project project = new Project();
		model.addAttribute("project", project);
		model.addAttribute("listEmployee", employeeservice.Get());
		return "new_project";
	}
	
	@GetMapping("/updateProjectForm/{id}")
	public String updateProjectForm(@PathVariable(value="id")int id, Model model)
	{
		
		model.addAttribute("project", service.GetById(id));
		model.addAttribute("listEmployee", employeeservice.Get());
		return "new_project";
	}
	
	
	@GetMapping("/deleteProject/{id}")
	public String Delete(@PathVariable(value ="id") int id)
	{
		service.Delete(id);
		return "redirect:/projects";
	}
	
	
	@GetMapping("/infoProject/{id}")
	public String infoProject(@PathVariable(value="id")int id, Model model)
	{
		Project project = service.GetById(id);
		model.addAttribute("project", project);
		//model.addAttribute("listEmployee", employeeservice.Get());
		return "info_project";
	}

}
