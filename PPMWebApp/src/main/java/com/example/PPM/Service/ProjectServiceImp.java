package com.example.PPM.Service;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.PPM.Model.Employee;
import com.example.PPM.Model.Project;
import com.example.PPM.Repo.ProjectRepo;

@Service
public class ProjectServiceImp implements ProjectService
{
	@Autowired
	private ProjectRepo repo;
	
	@Override
	public List<Project> Get() {
		return repo.findAll();	
	}

	@Override
	public void Save(Project project) {
		repo.save(project);
		
	}

	@Override
	public Project GetById(int id) {

		Optional<Project> optional = repo.findById(id);
		Project project = null;
		if(optional.isPresent())
		{
			project = optional.get();
		}
		else
		{
			throw new RuntimeException("Project is not found for ProjectId : "+id);
		}
		return project;
	}

	@Override
	public void Delete(int id) {
		repo.deleteById(id);
		
	}
	
	
	
	
}
